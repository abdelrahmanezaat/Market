using Application.Contract.IFeatures;
using Application.Contract.IFeatures.IOrder;
using Application.Exceptions;
using Domin.Entities.Commin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers.Common
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public abstract class BaseController<TEntity, TGetDto, TCreateDto, TUpdateDto> : ControllerBase
		where TEntity : BaseEntity
		where TGetDto : class
		where TCreateDto : class
		where TUpdateDto : class
	{
		protected readonly IBaseService<TEntity, TGetDto, TCreateDto, TUpdateDto> _service;
		private IOrderService orderService;

		protected BaseController(IBaseService<TEntity, TGetDto, TCreateDto, TUpdateDto> service)
		{
			_service = service;
		}

		protected BaseController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll()
		{
			var entities = await _service.GetAllAsync();
			return Ok(entities);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(Guid id)
		{
			var entity = await _service.GetByIdAsync(id);
			return Ok(entity);
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
		public virtual async Task<IActionResult> Create(TCreateDto createDto)
		{
			try
			{
				var entity = await _service.CreateAsync(createDto);
				return Created("Create", entity.Id);
			}
			catch (SaveChangesFailedException scfex)
			{
				return BadRequest(scfex.Message + "\n may the ForeignKey Ids that are posted not Found in Database 'Check First'");
			}
		}


		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
		public async Task<IActionResult> CreateRange([FromBody] IEnumerable<TCreateDto> createDtos)
		{
			try
			{
				var statusOfCreate = await _service.CreateRangeAsync(createDtos);

				return Created("CreateRange", statusOfCreate);
			}

			catch (SaveChangesFailedException scfex)
			{
				return BadRequest(scfex.Message + "\n may the ForeignKey Ids that are posted not Found in Database 'Check First'");
			}
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
		public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateDto updateDto)
		{
			try
			{
				await _service.UpdateAsync(id, updateDto);
				return Ok(id);
			}
			catch (SaveChangesFailedException scfex)
			{
				return BadRequest(scfex.Message + "\n may the ForeignKey Ids that are posted not Found in Database 'Check First'");

			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _service.DeleteAsync(id);
			return Accepted();
		}
	}

}
