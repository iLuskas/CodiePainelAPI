using Codie.Painel.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Application.Services.Interface
{
    public interface IImagemService
    {
        Task Upload(ImagemDTO imagemDTO);
        Task<string> GetById(int imagemId);
        Task<List<string>> GetAllById(string tableAction, int tabeleId);
    }
}
