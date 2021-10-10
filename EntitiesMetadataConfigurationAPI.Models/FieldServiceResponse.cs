using System;

namespace EntitiesMetadataConfigurationAPI.Models
{
    public class FieldServiceResponse
    {
    	public string Field {get; set;}
        public bool IsRquired {get; set;}
        public int MaxLength{get; set;}
    }
}