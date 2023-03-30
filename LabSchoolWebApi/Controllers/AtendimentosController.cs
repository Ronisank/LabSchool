using AutoMapper;
using LabSchoolWebApi.Context;
using LabSchoolWebApi.DTOs;
using LabSchoolWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;


namespace LabSchoolWebApi.Controllers
{
    [Route("api/atendimentos")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AtendimentosController(LabSchoolContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        // PUT api/<AtendimentosController>/5
        [HttpPut()]
        public async Task<ActionResult> Put(AtendimentoRequisicaoDto atendimentoRequisicao, int codigoAluno, int codigoPedagogo)
        {
            var aluno = await _context.Alunos.FindAsync(codigoAluno);

            if (aluno is null)
            {
                return NotFound("Código aluno não cadastrado.");
            }
            
            if (codigoAluno is string)
            {
                return BadRequest("Código aluno não cadastrado, digite um número inteiro válido.");
            }

            if (aluno.Codigo != atendimentoRequisicao.CodigoAluno)
            {
                return NotFound("Código aluno não cadastrado.");
            }

            var pedagogo = await _context.Pedagogos.FindAsync(codigoPedagogo);

            if (pedagogo == null)
            {
                return NotFound("Código pedagogo não cadastrado");
            }
            if (pedagogo.Codigo != atendimentoRequisicao.CodigoPedagogo)
            {
                return BadRequest("Código pedagogo não cadastrado, digite um número inteiro válido.");
            }

            aluno.Situacao = "ATENDIMENTO_PEDAGOGICO";
            aluno.Atendimentos += 1;

            _context.Alunos.Update(aluno);

            pedagogo.Atendimentos += 1;
            _context.Pedagogos.Update(pedagogo);

            await _context.SaveChangesAsync();

            PedagogoRespostaDTO pedagogos = _mapper.Map<PedagogoRespostaDTO>(pedagogo);
            AlunoRespostaDto alunos = _mapper.Map<AlunoRespostaDto>(aluno);


            return new ObjectResult(new { alunos, pedagogos }) { StatusCode = StatusCodes.Status200OK };

        }

    }
}
