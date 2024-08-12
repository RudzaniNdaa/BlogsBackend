using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.API.Services.Foundations.Comments
{
    public partial class CommentService
    {
        private static void ValidateSecurityRequirement(List<string> securityRoles)
        {
            // Do security check here.
            // throw new ForbiddenCommentException();

            // Entity specific security checks can be done with the locigal validation
            // e.g.  person that submitted the application, can not be same as approver.
        }
    }
}