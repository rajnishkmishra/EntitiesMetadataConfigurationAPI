using System.Collections.Generic;

namespace EntitiesMetadataConfigurationAPI.Models
{
    public class Result
    {
    	public string Entity {get; set;}

    	public List<FieldsResult> Fields {get; set;}
    }
}