using Admin.Domain.Interfaces;
using Admin.Domain.Logging.Interfaces;
using System;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IMessageTemplateRepository _repository;
        private readonly IMessageTransmissionStrategy _transmissionStrategy;
        private readonly ILoggerFactory _loggerFactory;

        private readonly Messenger _messenger;

        public CreateUserService(
            IMessageTemplateRepository repository,
            IMessageTransmissionStrategy transmissionStrategy,
            ILoggerFactory loggerFactory
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _transmissionStrategy = transmissionStrategy ?? throw new ArgumentNullException(nameof(transmissionStrategy));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));

            _messenger = new Messenger(repository, transmissionStrategy,loggerFactory);
        }

        public async Task CreateUserAsync(User user)
        {
            Message message = new Message
            {
                Recipient = user,
                MessageTemplateKind = MessageTemplateConstants.UserIsCreatedOk.ToString(),
                Culture = user.PreferredCulture,
                Parameters = new object[]
                {
                    user.Name
                }
            };
            await _messenger.SendAsync(message);
        }
    }
}
