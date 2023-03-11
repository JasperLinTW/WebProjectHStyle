﻿using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class EssayController : ControllerBase
	{
		private EssayService _service;
		private readonly int _memberId;
		public EssayController(AppDbContext db, IHttpContextAccessor httpContextAccessor)
		{
			_service = new EssayService(db);
			var claims = httpContextAccessor.HttpContext.User.Claims;
			if (claims.Any())
			{
				var data = int.TryParse(claims.Where(x => x.Type == "MemberId").FirstOrDefault().Value, out int memberid);
				_memberId = memberid;
			}
		}
		// GET: api/<EssayController>
		[HttpGet]
		//FromQuery  =傳value篩選 代 service rpst
		public async Task<IEnumerable<EssayDTO>> GetEssays([FromQuery] string? keyword)
		{
			IEnumerable<EssayDTO> data = await _service.GetEssays(keyword);
			return data;
		}

		// GET api/<EssayController>/5
		[HttpGet("{id}")]
		public async Task<EssayDTO> GetEssay(int id)
		{

			return await _service.GetEssays(id);
		}

        //[HttpGet("News")] 
        [HttpGet("News")]
        public async Task<IEnumerable<EssayDTO>> GetNews()
        {
            return await _service.GetNews();
        }



		// GET api/<EssayController>/EssayLike/5
		[Authorize]
		[HttpGet("Elike")]
		public async Task<IEnumerable<EssayLikeDTO>> GetlikeEssays()
		{
			var memberId = _memberId;
			return await _service.GetlikeEssays(memberId);
		}
		// POST api/<EssayController>
		[Authorize]
		[HttpPost("Elike")]
		public void PostELike( int essayId)
		{
			var memberId = _memberId;
			_service.PostELike(memberId, essayId);
		}

		//GET api/<EssayController>/5 
		//GET 所有評論
		[HttpGet("Comments")]
		public async Task<IEnumerable<EssayCommentDTO>> GetComments(int essayId)
		{
			return await _service.GetComments(essayId);
		}

		//POST api/<VideoController>/Comment/5
		//POST 評論
		[Authorize]
		[HttpPost("Comment")]
		public void CreateComment([FromBody] string comment, int essayId)
		{
			var memberId = _memberId;
			_service.CreateComment(comment, memberId,essayId);
		}

		//POST api/<VideoController>/CommentLike
		[Authorize]
		[HttpPost("CommentLike")]
		public void PostCommentLike(int essayId)
		{
			var memberId = _memberId;
			_service.PostCommentLike(memberId, essayId);
		}
		//[HttpGet("Comments")]
		//public async Task<IEnumerable<EssayLikeDTO>> GetComments(int memberId)

		// PUT api/<EssayController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<EssayController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
