using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Configurations.TryCatches;

namespace Blogs.API.Services.Foundations.Authors
{
    public partial class AuthorService
    {
        static readonly ActivitySource source = new ActivitySource("Blog.API");

        private async ValueTask<Author> WithTracing(
            ReturningAuthorFunction returningAuthorFunction,
            Operation<ValueTask<Author>> operation)
        {
            var withTracing = operation.WithTracing;

            if (withTracing != null)
            {
                using (var activity = source.StartActivity(withTracing.ActivityName, ActivityKind.Internal)!)
                {
                    SetupActivity(activity, withTracing.ActivityName, withTracing.Tags, withTracing.Baggage);
                    var result = await returningAuthorFunction();

                    return result;
                }
            }

            return await returningAuthorFunction();
        }

        private static void SetupActivity(
            Activity activity,
            string activityName,
            Dictionary<string, string> tags = null,
            Dictionary<string, string> baggage = null)
        {
            if (activity == null)
            {
                activity = new Activity(activityName);
            }

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    activity.AddTag(tag.Key, tag.Value);
                }
            }

            if (baggage != null)
            {
                foreach (var baggageItem in baggage)
                {
                    activity.AddBaggage(baggageItem.Key, baggageItem.Value);
                }
            }
        }

        private static string FormatTraceMessage(string message)
        {
            StringBuilder traceMessage = new StringBuilder();
            traceMessage.Append(message);
            traceMessage.AppendLine($"ParentSpanId: {Activity.Current.ParentSpanId}");
            traceMessage.AppendLine($"ParentId: {Activity.Current.ParentId}");
            traceMessage.AppendLine($"SpanId: {Activity.Current.SpanId}");
            traceMessage.AppendLine($"Id: {Activity.Current.Id}");

            return traceMessage.ToString();
        }
    }
}