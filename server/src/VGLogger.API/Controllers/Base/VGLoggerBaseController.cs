using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace VGLogger.API.Controllers.Base
{
    public class VGLoggerBaseController : ControllerBase
    {
        protected ActionResult OkOrNoContent(object value)
        {
            if (HasNoValueOrItems(value)) return NoContent();

            return Ok(value);
        }

        protected ActionResult OkOrNotFound(object value)
        {
            if (HasNoValueOrItems(value)) return NotFound();

            return Ok(value);
        }

        private static bool HasNoValueOrItems(object value) => value == null || value is IList { Count: < 1 };
    }
}
