﻿using Application.GeoJson.Features;
using Application.GeoJson.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.GeoJson.Converters
{
	public class GeoJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(IGeoJSONObject).IsAssignableFromType(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.Null:
					return null;
				case JsonToken.StartObject:
					var value = JObject.Load(reader);
					return ReadGeoJson(value);
				case JsonToken.StartArray:
					var values = JArray.Load(reader);
					var geometries = new List<IGeoJSONObject>(values.Count);
					geometries.AddRange(values.Cast<JObject>().Select(ReadGeoJson));
					return geometries;
			}

			throw new JsonReaderException("expected null, object or array token but received " + reader.TokenType);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, value);
		}

		private static IGeoJSONObject ReadGeoJson(JObject value)
		{
			JToken token;

			if (!value.TryGetValue("type", StringComparison.OrdinalIgnoreCase, out token))
			{
				throw new JsonReaderException("json must contain a \"type\" property");
			}

			GeoJSONObjectType geoJsonType;

			if (!Enum.TryParse(token.Value<string>(), true, out geoJsonType))
			{
				throw new JsonReaderException("type must be a valid geojson object type");
			}

			switch (geoJsonType)
			{
				case GeoJSONObjectType.Point:
					return value.ToObject<Point>();
				case GeoJSONObjectType.LineString:
					return value.ToObject<LineString>();
				case GeoJSONObjectType.Polygon:
					return value.ToObject<Polygon>();
				case GeoJSONObjectType.MultiPolygon:
					return value.ToObject<MultiPolygon>();
				case GeoJSONObjectType.Feature:
					return value.ToObject<Feature>();
				case GeoJSONObjectType.FeatureCollection:
					return value.ToObject<FeatureCollection>();
				default:
					throw new NotSupportedException($"Unknown geoJsonType {geoJsonType}");
			}
		}
	}
}
