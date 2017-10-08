using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extensions;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryServie;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryServie = postCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                 

                var listCategory = _postCategoryServie.GetAll();
                var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                _postCategoryServie.Save();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);

                return response;

            });
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (ModelState.IsValid)
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     PostCategory newPostCategory = new PostCategory();
                     newPostCategory.UpdatePostCategory(postCategoryVm);
                     var category = _postCategoryServie.Add(newPostCategory);
                     _postCategoryServie.Save();

                     response = request.CreateResponse(HttpStatusCode.Created, category);
                 }
                 return response;

             });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var postCategoryDb = _postCategoryServie.GetById(postCategoryVm.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVm);

                    _postCategoryServie.Update(postCategoryDb);
                    _postCategoryServie.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;

            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryServie.Delete(id);
                    _postCategoryServie.Save();

                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;

            });
        }
    }
}