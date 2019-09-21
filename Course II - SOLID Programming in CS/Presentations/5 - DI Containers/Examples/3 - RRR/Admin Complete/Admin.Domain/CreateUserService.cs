using Admin.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IMessageTemplateRepository _repository;
        private readonly IMessageTransmissionStrategy _transmissionStrategy;

        private readonly Messenger _messenger;

        public CreateUserService(
            IMessageTemplateRepository repository,
            IMessageTransmissionStrategy transmissionStrategy)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _transmissionStrategy = transmissionStrategy ?? throw new ArgumentNullException(nameof(transmissionStrategy));

            _messenger = new Messenger(repository, transmissionStrategy);
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
