﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VitualReception.Domain.Model;
using System;


namespace VirtualReception.Server.Controllers
{
    [Route("chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region dependencies

        private readonly IChatRepository _chatRepository;

        #endregion

        #region ctors

        /// <summary>
        /// Constructs a <see cref="ChatController"/> instance.
        /// </summary>
        /// <param name="chatRepository">A collection of <see cref="Chat"/> instances.</param>
        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            return Ok(await _chatRepository.FindAllAsync());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetChatById(Guid id) {
            Chat chat = await _chatRepository.FindAsync(id);

            return Ok(chat);
        }

    }
}
