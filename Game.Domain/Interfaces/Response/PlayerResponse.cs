﻿using Game.Domain.Entities;

namespace Game.Domain.Interfaces.Response
{
    public class PlayerResponse : BaseResponse
    {
        public Player Player { get; set; }
    }
}
