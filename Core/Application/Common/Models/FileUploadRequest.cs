using FluentValidation;

namespace Core.Application.Common.Models
{
    public class FileUploadRequest {
        public string Name { get; set; } = default!;
        public string Extension { get; set; } = default!;
        public string Data { get; set; } = default!;
    }

    public class FileUploadRequestValidator : AbstractValidator<FileUploadRequest> {
        public FileUploadRequestValidator() {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(150);
            RuleFor(p => p.Extension).NotEmpty().MaximumLength(5);
            RuleFor(p => p.Data).NotEmpty();
        }
    }
}

