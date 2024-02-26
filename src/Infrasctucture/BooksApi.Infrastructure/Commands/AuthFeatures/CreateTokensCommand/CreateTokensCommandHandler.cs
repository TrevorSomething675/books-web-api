﻿using BooksApi.Core.Abstractions.Repositories;
using BooksApi.Core.Abstractions.Services;
using Ardalis.Result.FluentValidation;
using BooksApi.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace BooksApi.Infrastructure.Commands.AuthFeatures.CreateTokensCommand
{
    public class CreateTokensCommandHandler(
        ITokenService tokenService,
        IRoleRepository roleRepository,
        IValidator<CreateTokensCommand> commandValidator) : IRequestHandler<CreateTokensCommand, Result<AuthWithTokensModel>>
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IValidator<CreateTokensCommand> _commandValidator = commandValidator;
        public async Task<Result<AuthWithTokensModel>> Handle(CreateTokensCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<AuthWithTokensModel>.Invalid(validationResult.AsErrors());

            var roleNames = (await _roleRepository.GetRoles()).Select(r => r.UserRole.ToString());
            if (!roleNames.Contains(request.Role))
                return Result<AuthWithTokensModel>.NotFound("Такой роли не существует");

            var tokens = await _tokenService.GetTokens(request.Role);
            return Result<AuthWithTokensModel>.Success(tokens);
        }
    }
}