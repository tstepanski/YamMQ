using System.Threading.Tasks;

namespace YamMQ.Api.Helpers
{
    public sealed class EmptyTask
    {
        public static Task Start()
        {
            var taskSource = new TaskCompletionSource<AsyncVoid>();

            taskSource.SetResult(default(AsyncVoid));

            return taskSource.Task;
        }

        private struct AsyncVoid
        {
        }
    }
}