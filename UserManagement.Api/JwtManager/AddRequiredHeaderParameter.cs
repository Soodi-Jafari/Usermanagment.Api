using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace AuthManager
{

    public class ActiveBusinessFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor != null && descriptor.ControllerName.StartsWith("Employer"))
            {
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "active_business",
                    In = ParameterLocation.Header,
                    Required = false
                });
            }
        }
    }
}
