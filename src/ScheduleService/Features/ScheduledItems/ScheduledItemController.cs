using ScheduleService.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static ScheduleService.Features.ScheduledItems.AddOrUpdateScheduledItemCommand;
using static ScheduleService.Features.ScheduledItems.GetScheduledItemsQuery;
using static ScheduleService.Features.ScheduledItems.GetScheduledItemByIdQuery;
using static ScheduleService.Features.ScheduledItems.RemoveScheduledItemCommand;

namespace ScheduleService.Features.ScheduledItems
{
    [Authorize]
    [RoutePrefix("api/scheduledItem")]
    public class ScheduledItemController : ApiController
    {
        public ScheduledItemController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateScheduledItemResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateScheduledItemRequest request)
        {
            request.TenantId = (await _userManager.GetUserAsync(User)).TenantId;
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateScheduledItemResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateScheduledItemRequest request)
        {
            request.TenantId = (await _userManager.GetUserAsync(User)).TenantId;
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetScheduledItemsResponse))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetScheduledItemsRequest();
            request.TenantId = (await _userManager.GetUserAsync(User)).TenantId;
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetScheduledItemByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetScheduledItemByIdRequest request)
        {
            request.TenantId = (await _userManager.GetUserAsync(User)).TenantId;
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveScheduledItemResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveScheduledItemRequest request)
        {
            request.TenantId = (await _userManager.GetUserAsync(User)).TenantId;
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}
