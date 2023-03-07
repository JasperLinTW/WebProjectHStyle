﻿using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class HCoinController : ControllerBase
	{
		private HCoinService _service;
		public HCoinController(AppDbContext db)
		{
			_service = new HCoinService(db);
		}

		// GET: api/<HCoinController>
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		// GET api/<HCoinController>/5
		// 得到打卡資料
		[HttpGet("CheckIn/{memberId}")]
		public async Task<HCheckInDTO> GetHCheckIn(int memberId)
		{
			if (memberId <=0)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				// 活動Id和項目
				int activityId_checkIn = 3;
				return await _service.GetHCheckIn(memberId, activityId_checkIn);
			}
		}

		// PUT api/<HCoinController>/5
		// 將打卡紀錄傳回資料庫
		[HttpPut("CheckIn/{memberId}")]
		public async Task<ActionResult> PutCheckIn(int memberId)
		{
			if (memberId <= 0)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				string response = await _service.PutCheckInById(memberId);
				return Ok(response);
			}
		}

		// 取得花費活動的規則
		[HttpGet("CostHCoin")]
		public async Task<IEnumerable<HActivityDTO>> GetCostRule()
		{
			// 滿{多少}金額；可花費的上限，滿額的{多少}%
			return await _service.GetCostHCoinRule();
		}

		// 取得會員的總HCoin金額
		[HttpGet("TotalHCoin/{memberId}")]
		public async Task<int> GetTotalHCoin(int memberId)
		{
			if (memberId == null)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				return await _service.GetTotalHCoinByMemberId(memberId);
			}
		}

		// 將會員花費的HCoin記錄到
		// POST api/<HCoinController>
		[HttpPost("CostHCoin/{memberId}")]
		public void PostCostHCoin(int memberId, [FromBody] int value)
		{
			if (memberId == null)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				// 將會員花費的HCoin記錄到會員的活動中
				_service.PostCostHCoinByMemberId(memberId, value);
			}
		}

		//// DELETE api/<HCoinController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
