using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models.ResponseModel;
using Northwind.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TModel> : ControllerBase where T : class where TModel : class
    {

        private readonly IService<T, TModel> _service;
        public BaseController(IService<T, TModel> service)
        {
            _service = service;
        }
        [HttpPost("Add")]
        public ResponseModel<TModel> Add([FromBody]TModel model)
        {
            try
            {
                return new ResponseModel<TModel>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = _service.Add(model),
                    Message = "Succes"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<TModel>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Message = ex.Message
                };
            }
        }
        [HttpDelete("Delete")]
        public ResponseModel<bool> Delete(int id)
        {
            try
            {
                return new ResponseModel<bool>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = _service.Delete(id),
                    Message = "Succes"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = false,
                    Message = ex.Message
                };
            }
        }
        [HttpGet("GetAll")]
        public ResponseModel<List<TModel>> GetAll()
        {
            try
            {
                return new ResponseModel<List<TModel>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = _service.GetAll().ToList(),
                    Message = "Successful"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<TModel>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Message = ex.Message
                };
            }
        }
        [HttpGet("GetById")]
        public ResponseModel<TModel> GetById(int id)
        {
            try
            {
                return new ResponseModel<TModel>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = _service.GetById(id),
                    Message = "Succes"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<TModel>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Message = ex.Message
                };
            }
        }
        [HttpPut("Update")]
        public ResponseModel<TModel> Update(TModel model)
        {
            try
            {
                return new ResponseModel<TModel>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = _service.Update(model),
                    Message = "Succes"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<TModel>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Message = ex.Message
                };
            }
        }
    }
}

