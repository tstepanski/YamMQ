using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamMQ.General.Types;
using YamMQ.SimpleClient;

namespace YamMQ.TestPublishApplication
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();

            ResetCancellationTokenSource();

            ResetMessageTemplate();
        }

        private void ResetCancellationTokenSource() => _cancellationTokenSource = new CancellationTokenSource();

        private void CancelButton_Click(object sender, EventArgs e) => _cancellationTokenSource.Cancel();

        private void PublishButton_Click(object sender, EventArgs e)
        {
            ResetCancellationTokenSource();

            var url = PublishUrlTextBox.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(@"You must provide a publish URL to publish.", @"Error Publishing", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var userEnteredCode = MessageTypeDefinitionTextBox.Text;

            IEnumerable<IMessage> messages;

            try
            {
                messages = RuntimeCompilationHelper.CreateMessages(userEnteredCode);
            }
            catch (Exception exception)
            {
                DisplayException(exception);

                return;
            }

            var messageService = new SimpleMessageService(factory => factory.CreateWithoutAnyAuthentication(url));

            var publishTasks =
                messages.Select(message => messageService.PublishMessageAsync(message, _cancellationTokenSource.Token));

            CancelButton.Enabled = true;
            PublishButton.Enabled = false;
            
            Application.DoEvents();

            Task
                .WhenAll(publishTasks)
                .ContinueWith(async publishAllTask =>
                {
                    try
                    {
                        await publishAllTask;

                        MessageBox.Show(@"Published successfully.", @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {
                        DisplayException(exception);
                    }
                    finally
                    {
                        CancelButton.Enabled = false;
                        PublishButton.Enabled = true;

                        Application.DoEvents();
                    }
                });
        }

        private void DisplayException(Exception exception)
        {
            var exceptionAsAggregateException = exception as AggregateException;

            if (exceptionAsAggregateException != null)
            {
                exception = exceptionAsAggregateException.Flatten();
            }

            MessageBox.Show(exception.ToString(), @"Error Publishing", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void GetTemplateButton_Click(object sender, EventArgs e) => ResetMessageTemplate();

        private void ResetMessageTemplate()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(@"using System;");
            stringBuilder.AppendLine(@"using YamMQ.General.Types;");
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine(@"public sealed class SomeMessage : IMessage");
            stringBuilder.AppendLine(@"{");
            stringBuilder.AppendLine("\t public Guid Id { get; set; }");
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine("\t// Your code goes here...");
            stringBuilder.AppendLine(@"}");

            MessageTypeDefinitionTextBox.Text = stringBuilder.ToString();
        }
    }
}