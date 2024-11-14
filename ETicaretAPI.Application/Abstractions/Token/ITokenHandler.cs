﻿using ETicaretAPI.Application.Data_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int min);
        string CreateRefreshToken();
    }
}
