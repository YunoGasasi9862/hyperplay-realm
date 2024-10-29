﻿using BLL.Load;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class GameGenresServiceImpl : LoadResult
    {
        public GameGenresServiceImpl(HyperplayRealmDBContext hyperplayRealmDBContext, ResultMessages resultMessages) : base(hyperplayRealmDBContext, resultMessages)
        {
        }
    }
}
