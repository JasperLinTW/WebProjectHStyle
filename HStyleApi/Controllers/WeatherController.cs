﻿using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HStyleApi.Models.DTOs.WeatherDTO;

namespace HStyleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private static readonly HttpClient httpClient = new HttpClient();
		private const string WeatherUrl = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001";
		private const string ApiKey = "CWB-91FC1B09-0AA9-4FCA-9EEB-0B87566FF0DE"; // 記得填入自己的API金鑰
		private readonly ProductServices _Service;
		private readonly AppDbContext _db;

		public WeatherController(AppDbContext db)
		{
			_Service = new ProductServices(db);
			_db = db;
		}


		[HttpGet("weather")]
		public async Task<string> GetWeather(string? locationName)
		{
			string responseContent;
			//TODO locationName 可用HTML5的 Geolocation API取得 

			var timeFrom = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
			var timeTo = DateTime.Now.AddHours(6).ToString("yyyy-MM-ddThh:mm:ss");

			var url = $"{WeatherUrl}?Authorization={ApiKey}&locationName={locationName}&elementName=CI&timeFrom={timeFrom}&timeTo={timeTo}";

			// 發送HTTP請求，取得天氣資訊JSON
			var response = await httpClient.GetAsync(url);
			responseContent = await response.Content.ReadAsStringAsync();
			var data = JObject.Parse(responseContent);

			string weatherdescription = (string)data["records"]["location"][0]["weatherElement"][0]["time"][0]["parameter"]["parameterName"];
			return weatherdescription;
		}


	}
}
