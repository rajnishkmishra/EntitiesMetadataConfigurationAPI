using System;

namespace EntitiesMetadataConfigurationAPI.Models
{
    public class FieldsResult
    {
    	public string Field {get; set;}
        public bool IsRquired {get; set;}
        public int MaxLength{get; set;}
        public string Source {get; set;}
    }
}