using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchoolWebApi.Context;
using LabSchoolWebApi.Models;
using AutoMapper;
using LabSchoolWebApi.DTOs;

namespace LabSchoolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AlunosController(LabSchoolContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos(string? situacao)
        {
            var alunos = await _context.Alunos.ToListAsync();

            if (situacao is not null)
            {
                var alunosParamQuery = alunos.Where(x => x.Situacao.ToString() == situacao.ToUpper());

                if (alunosParamQuery.Count() == 0)
                {
                    return NotFound("Parâmetro não encontrado");
                }
                List<AlunoRespostaDto> alunoDTO = _mapper.Map<List<AlunoRespostaDto>>(alunosParamQuery);
                return Ok(alunoDTO);
            }

            else
            {
                List<AlunoRespostaDto> alunoDTO = _mapper.Map<List<AlunoRespostaDto>>(alunos);
                return Ok(alunoDTO);
            }
        }



        // GET: api/Alunos/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Aluno>> GetAluno(int codigo)
        {
            var aluno = await _context.Alunos.FindAsync(codigo);
            AlunoRespostaDto alunoDTO = _mapper.Map<AlunoRespostaDto>(aluno);

            if (aluno == null)
            {
                return NotFound("Código não cadastrado.");
            }


            return Ok(alunoDTO);
        }


        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlunoRespostaDto>> Post([FromBody] AlunoDTO alunoDto)
        {

            var validacaoCpf = await _context.Alunos.Where(x => x.CPF == alunoDto.CPF).FirstOrDefaultAsync();

            if (validacaoCpf is not null)
            {
                return Conflict("CPF já cadastrado para outro aluno");
            }

            Aluno aluno = _mapper.Map<Aluno>(alunoDto);

            if (aluno.Nome == null)
            {
                return BadRequest("O nome não foi informado.");
            }
            if (aluno.Telefone == string.Empty)
            {
                return BadRequest("O Número de telefone não foi informado.");
            }
            if (aluno.DataNascimento == null)
            {
                return BadRequest("A Data de nascimento não foi informada.");
            }

            aluno.Situacao = alunoDto.Situacao.ToUpper();

            if (aluno.Situacao == null)
            {
                return BadRequest("Situação não encontrada.");
            }

            switch (aluno.Situacao)
            {
                case "ATIVO":
                    break;

                case "INATIVO":
                    break;

                case "IRREGULAR":
                    break;

                case "ATENDIMENTO_PEDAGOGICO":
                    break;

                default:
                    return BadRequest("Situação não encontrada. Os valores para situação são: ATIVO, IRREGULAR, ATENDIMENTO_PEDAGOGICO, INATIVO");
            }

            if (alunoDto.Nota < 0 || alunoDto.Nota > 10)
            {
                return BadRequest("A nota deve ser entre 0 e 10");
            }

            _context.Alunos.Add(aluno);

            await _context.SaveChangesAsync();

            AlunoRespostaDto alunos = _mapper.Map<AlunoRespostaDto>(aluno);

            return new ObjectResult(alunos) { StatusCode = StatusCodes.Status201Created };
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{codigo}")]
        public async Task<ActionResult<AlunoRespostaDto>> PutAluno(int codigo, AlunoSituacaoDTO situacao)
        {
            var alunos = await _context.Alunos.FindAsync(codigo);

            if (alunos == null)
            {
                return NotFound("Código não cadastrado.");
            }

            alunos.Situacao = situacao.Situacao.ToUpper();

            if (alunos.Situacao == null)
            {
                return BadRequest("Situação não encontrada.");
            }

            _context.Alunos.Update(alunos);

            await _context.SaveChangesAsync();

            AlunoRespostaDto aluno = _mapper.Map<AlunoRespostaDto>(alunos);

            switch (alunos.Situacao)
            {
                case "ATIVO":
                    return new ObjectResult(aluno);

                case "INATIVO":
                    return new ObjectResult(aluno);

                case "IRREGULAR":
                    return new ObjectResult(aluno);

                case "ATENDIMENTO_PEDAGOGICO":
                    return new ObjectResult(aluno);

                default:
                    return BadRequest("Situação não encontrada.");
            }

        }

        // DELETE: api/Alunos/5
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteAluno(int codigo)
        {
            var aluno = await _context.Alunos.FindAsync(codigo);
            AlunoDTO alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            if (aluno == null)
            {
                return NotFound("Código não cadastrado.");
            }
            if (_context.Alunos == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

