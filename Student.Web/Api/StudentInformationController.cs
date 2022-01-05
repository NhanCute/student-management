using Newtonsoft.Json;
using Student.Model.Models;
using Student.Service;
using Student.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Student.Web.Api
{
    [RoutePrefix("api/StudentInformation")]
    public class StudentInformationController : ApiControllerBase
    {
        private IStudentInformationService _studentInformationService;
        public StudentInformationController(IErrorService errorService, IStudentInformationService StudentInformationService)
            : base(errorService)
        {
            this._studentInformationService = StudentInformationService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _studentInformationService.GetAll().ToList();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);

                return response;
            });
        }

        [Route("getalldk")]
        [HttpGet]
        public HttpResponseMessage Getdk(HttpRequestMessage request, string dk)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _studentInformationService.getTenTheodk(dk);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);

                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, StudentInformation StudentInformation)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //StudentInformation.ID = Guid.NewGuid().ToString();
                    //var student = _studentInformationService.Add(StudentInformation);
                    //_studentInformationService.Save();

                    //response = request.CreateResponse(HttpStatusCode.Created, student);

                    StudentInformation.ID = Guid.NewGuid().ToString();

                    var student = _studentInformationService.SaveStudent(StudentInformation);

                    _studentInformationService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, student);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, StudentInformation StudentInformation)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _studentInformationService.Update(StudentInformation);
                    _studentInformationService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _studentInformationService.Delete(id);
                    _studentInformationService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}