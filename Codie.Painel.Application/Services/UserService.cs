using Codie.Painel.Application.Dtos.Validations;
using Codie.Painel.Application.Dtos;
using Codie.Painel.Domain.Authentication;
using Codie.Painel.Domain.Entities;
using Codie.Painel.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Codie.Painel.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
        }
        public async Task<ResultService<TokenDto>> GetAuthAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return ResultService.Fail<TokenDto>("Os dados da requisição devem ser informados!");

            var validate = new LoginDTOValidator().Validate(loginDTO);

            if (!validate.IsValid)
                return ResultService.RequestError<TokenDto>("Os dados da requisição estão inválidos.", validate);

            var user = await _userRepository.GetUserByloginAndPasswordAsync(loginDTO.Login!, loginDTO.Password!);

            if (user == null)
                return ResultService.Fail<TokenDto>("Usuário ou senha não encontrado!");

            var token = _tokenGenerator.Generator(user);

            TokenDto tokendto = new()
            {
                User = _mapper.Map<UserDTO>(user),
                Token = token,
                Expires = DateTime.UtcNow.AddDays(1)
            };

            return ResultService.Ok(tokendto);
        }
    }
}
