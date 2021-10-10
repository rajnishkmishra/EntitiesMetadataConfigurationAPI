using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EntitiesMetadataConfigurationAPI.Models;
using Newtonsoft.Json;

namespace EntitiesMetadataConfigurationAPI.Services
{
	public interface IConfigurationService
	{
        Result GetResult(string entity);
	}

    public class ConfigurationService : IConfigurationService
    {
    	public Result GetResult(string entity)
    	{

    		var defaultFields = GetDefaultFields(entity);
    		var customFields = GetCustomFields(entity);

    		Result result = new Result();
            result.Entity = entity;
            result.Fields = new List<FieldsResult>();

    		foreach(var defaultField in defaultFields)
    		{
                FieldsResult fieldsResult = new FieldsResult();
                fieldsResult.Field = defaultField.Field;
                fieldsResult.IsRquired = defaultField.IsRquired;
                fieldsResult.MaxLength = defaultField.MaxLength;
                fieldsResult.Source = "Source1";
                result.Fields.Add(fieldsResult);
    		}
    		foreach(var customField in customFields)
    		{
    			FieldsResult fieldsResult = new FieldsResult();
                fieldsResult.Field = customField.Field;
                fieldsResult.IsRquired = customField.IsRquired;
                fieldsResult.MaxLength = customField.MaxLength;
                fieldsResult.Source = "Source2";
                result.Fields.Add(fieldsResult);
    		}
            return result;
    	}

    	private List<FieldServiceResponse> GetDefaultFields(string entity)
    	{
            string res="";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(string.Format("https://adcd9531-31e7-43ba-a9fc-78f17202b0ba.mock.pstmn.io/API/DefaultFields/{0}",entity));
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var response = responseTask.Result;
                
                if (response.IsSuccessStatusCode)
                {
                    res = response.Content.ReadAsStringAsync().Result;
                }
            }
            return JsonConvert.DeserializeObject<List<FieldServiceResponse>>(res);
    	}

    	private List<FieldServiceResponse> GetCustomFields(string entity)
    	{
            string res="";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(string.Format("https://e49275a1-17f8-4987-b1f3-9008b8a59c19.mock.pstmn.io/API/CustomFields/{0}",entity));
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var response = responseTask.Result;
                
                if (response.IsSuccessStatusCode)
                {
                    res = response.Content.ReadAsStringAsync().Result;
                }
            }
            return JsonConvert.DeserializeObject<List<FieldServiceResponse>>(res);
    	}
    }
}
