using Endpoints_Creation.Enums;
using Endpoints_Creation.Models;
using Endpoints_Creation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Endpoints_Creation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagAssociationsController : ControllerBase
    {
        private readonly ITagFrameworkService _tagFrameworkService;
        private readonly IMapper _mapper;
        private readonly ITagAssociationCommandService _service;
        public TagAssociationsController(
            ITagFrameworkService tagFrameworkService,
            IMapper mapper)
        {
            _tagFrameworkService = tagFrameworkService;
            _mapper = mapper;
        }

        [HttpPost("tag-association")]
        public async Task<IActionResult> TagAssociationGenericInsert(
            TagAssociationsInputModel input)
        {
            if (input == null)
                return BadRequest("Invalid Input");

            var dto = _mapper.Map<TagAssociationsDto>(input);
            var response = new ResponseModel();

            if (input.TASource == "UP")
            {
                if (dto.TagAssociationsRefEntity ==
                    TagAssociationsRefEntity.RESOURCE.ToString())
                {
                    dto.TagAssociationsRefEntityKey =
                        await _tagFrameworkService.TagMasterQueryService
                            .GetResourceId(dto);
                }

                response.Message =
                    await _tagFrameworkService.TagAssociationsValidationService
                        .CheckCommonValidations(dto);
            }

            if (string.IsNullOrEmpty(response.Message))
            {
                response =
                    await _tagFrameworkService.TagAssociationCommandService
                        .CreateTagAssociationCommand(dto);
            }

            return Ok(response);
        }

        [HttpPost("CreateTag")]

        public async Task<IActionResult> CreateTag([FromBody] TagMasterDtos dto)
        {
            var result = await _tagFrameworkService.TagAssociationCommandService.
                CreateTagAssociationbuilt(dto);
        
            return Ok(result);
        }


            //[HttpPost("tag-association")]
            //public async Task<IActionResult> CreateTagAssociation(
            //    [FromBody] TagAssociationRequestDto request)
            //{
            //    if (!ModelState.IsValid)
            //        return BadRequest(ModelState);

            //    var result = new ResponseModel(); 

            //    return Ok(result);
            //}


            [HttpPost("get-tag-list")]
        public async Task<IActionResult> GetTagList(
            [FromBody] TagAssociationsInputModel input)
        {
            if (input == null)
                return BadRequest("Invalid Input");

            try
            {
                var dto = _mapper.Map<TagAssociationsDto>(input);

                var tagList =
                    await _tagFrameworkService.TagMasterQueryService
                        .GetTagDropdownList(dto);

                var result = new ResultModel();

                if (tagList == null || !tagList.Any())
                {
                    result.Message = "No Tags";
                }
                else
                {
                    result.TagMasterDtoList = tagList;
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Exception : {ex.Message}");
            }
        }
        // ============================================
        // .NET 8 - TagAssociationGenericDelete
        // ============================================

        [HttpPost("tag-association-delete")]
        public async Task<IActionResult> TagAssociationGenericDelete(
            [FromBody] TagAssociationsInputModel input)
        {
            if (input == null)
                return BadRequest("Invalid Input - TagAssociations Resource InputModel");

            try
            {
                var dto = _mapper.Map<TagAssociationsDto>(input);
                var response = new ResponseModel();

                // Upload Source + Resource logic
                if (dto.TagAssociationsSource == "UP" &&
                    dto.TagAssociationsRefEntity ==
                    TagAssociationsRefEntity.RESOURCE.ToString())
                {
                    dto.ResourcePersonnelNumber =
                        dto.TagAssociationsRefEntityKey?.ToString();

                    dto.TagAssociationsRefEntityKey =
                        await _tagFrameworkService.TagMasterQueryService
                            .GetResourceId(dto);

                    if (dto.TagAssociationsRefEntityKey == null)
                    {
                        response.Message += "Resource Does Not Exist";
                    }
                }

                if (string.IsNullOrEmpty(response.Message))
                {
                    // Entity validations
                    if (dto.TagAssociationsRefEntity ==
                        TagAssociationsRefEntity.OPSOURCINGDETAILS.ToString())
                    {
                        response.Message +=
                            await _tagFrameworkService.TagAssociationsValidationService
                                .CheckDemandValidations(dto);
                    }
                    else if (dto.TagAssociationsRefEntity ==
                             TagAssociationsRefEntity.RESOURCE.ToString())
                    {
                        response.Message +=
                            await _tagFrameworkService.TagAssociationsValidationService
                                .CheckResourceValidations(dto);
                    }

                    // Removal validation
                    response.Message +=
                        await _tagFrameworkService.TagAssociationsValidationService
                            .CheckRemovalValidations(dto);

                    // Execute delete if no validation errors
                    if (string.IsNullOrEmpty(response.Message))
                    {
                        response =
                            await _tagFrameworkService.TagAssociationCommandService
                                .DeleteTagAssociationsCommand(dto);
                    }
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Exception : {ex.Message}");
            }
        }

        // ============================================
        // .NET 8 - TagMasterAddRemove
        // ============================================

        [HttpPost("tag-master-add-remove")]
        public async Task<IActionResult> TagMasterAddRemove(
            [FromBody] TagMasterInputModel input)
        {
            if (input == null)
                return BadRequest("Invalid Input - TagMaster InputModel");

            try
            {
                var dto = _mapper.Map<TagMasterDto>(input);
                var response = new ResponseModel();

                if (input.TagAction.Equals("Add", StringComparison.OrdinalIgnoreCase))
                {
                    response.Message +=
                        await _tagFrameworkService.TagMasterValidationService
                            .CheckTagMasterAdditionValidation(dto);

                    if (string.IsNullOrEmpty(response.Message))
                    {
                        response =
                            await _tagFrameworkService.TagMasterCommand
                                .CreateTagMasterCommand(dto);
                    }
                }
                else if (input.TagAction.Equals("Remove", StringComparison.OrdinalIgnoreCase))
                {
                    response.Message +=
                        await _tagFrameworkService.TagMasterValidationService
                            .CheckTagMasterRemovalValidation(dto);

                    if (string.IsNullOrEmpty(response.Message))
                    {
                        response =
                            await _tagFrameworkService.TagMasterCommand
                                .DeleteTagMasterCommand(dto);
                    }
                }
                else
                {
                    response.Message = "Invalid TagAction. Use Add or Remove.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Exception : {ex.Message}");
            }
        }


    }
}
