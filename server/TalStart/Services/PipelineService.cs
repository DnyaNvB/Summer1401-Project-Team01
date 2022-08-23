﻿using TalStart.IServices;
using TalStart.Models;

namespace TalStart.Services
{
    public class PipelineService :IPipelineService
    {
        TalStartContext db = new TalStartContext();
        public PipelineService()
        {

        }
        public bool AddPipeline(string pipelineName)
        {
            return true;
        }
        public bool UpdateJSON(string JSON, string name) 
        {
            try
            {
                var pipeline = db.Pipelines.FirstOrDefault(p=>p.Name == name);
                if (pipeline == null)
                {
                    throw new Exception();
                }
                pipeline.JSON = JSON;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true; 
        }

        public bool AddSource(string sourceName, string pipelineName, string username)
        {
            try
            {
                var pipeline = db.Pipelines.FirstOrDefault(p => p.Name == pipelineName && p.User.Username == username);
                if (pipeline == null)
                {
                    return false;
                }
                var sourceDataset = db.dataSets.FirstOrDefault(d => d.Name == sourceName && d.User.Username == username);
                if (sourceDataset == null)
                {
                    return false;
                }
                pipeline.SourceDataset = sourceDataset;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool RemoveSource(string pipelineName, string username)
        {
            try
            {
                var pipeline = db.Pipelines.FirstOrDefault(p => p.Name == pipelineName && p.User.Username == username);
                if (pipeline == null)
                {
                    return false;
                }
                pipeline.SourceDataset = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddDestination(string destinationName, string pipelineName, string username)
        {
            try
            {
                var pipeline = db.Pipelines.FirstOrDefault(p => p.Name == pipelineName && p.User.Username == username);
                if (pipeline == null)
                {
                    return false;
                }
                var destinationDataset = db.dataSets.FirstOrDefault(d => d.Name == destinationName && d.User.Username == username);
                if (destinationDataset == null)
                {
                    return false;
                }
                pipeline.DestinationDataset = destinationDataset;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public bool RemoveDestination(string pipelineName, string username)
        {
            try
            {
                var pipeline = db.Pipelines.FirstOrDefault(p => p.Name == pipelineName && p.User.Username == username);
                if (pipeline == null)
                {
                    return false;
                }
                pipeline.DestinationDataset = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
