using ApiComAcessoBD.Dtos;
using ApiComAcessoBD.Models;
using AutoMapper;

namespace ApiComAcessoBD.Mapping
{
    public class AutoMapperRegistry : Profile
    {
        public AutoMapperRegistry()
        {
            //Mapeamento entre objetos Dto para os objetos Modelo
            //Mapeamento entre objetos Modelo para os objetos Dto
            CreateMap<PessoaDto, Pessoa>();
            CreateMap<Pessoa, PessoaDto>();

            CreateMap<PessoaFisicaDto, PessoaFisica>();
            CreateMap<PessoaFisica, PessoaFisicaDto>();

            CreateMap<PessoaJuridicaDto, PessoaJuridica>();
            CreateMap<PessoaJuridica, PessoaJuridicaDto>();

            CreateMap<PessoaTelefoneDto, PessoaTelefone>();
            CreateMap<PessoaTelefone, PessoaTelefoneDto>();

            CreateMap<PessoaEnderecoDto, PessoaEndereco>();
            CreateMap<PessoaEndereco, PessoaEnderecoDto>();
        }
    }
}
