namespace BullsAndCows.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using BullsAndCows.Data.Contracts;
    
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IBullsAndCowsData data)
        {
            this.Data = data;
        }

        protected IBullsAndCowsData Data { get; set; }
    }
}