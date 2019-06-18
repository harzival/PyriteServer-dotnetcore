namespace UniscanServer.DataAccess.Json
{
    using Microsoft.Xna.Framework;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    public class BoundingBoxConverter : JsonConverter 
    {
        public override bool CanConvert(Type objectType)
        {   
            if (objectType == typeof(BoundingBox))
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            dynamic t = JObject.Load(reader);
            return new BoundingBox();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            BoundingBox b = (BoundingBox)value;
            
            writer.WriteStartObject();
            writer.WritePropertyName("min");
            writer.WriteValue(b.Min);
            writer.WritePropertyName("max");
            writer.WriteValue(b.Max);
            writer.WriteEndObject();
        }
    }
}