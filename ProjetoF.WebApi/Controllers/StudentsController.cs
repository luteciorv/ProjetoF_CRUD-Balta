using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Application.Students.DTOs;
using ProjetoF.Application.Students.Queries;
using ProjetoF.Application.Subscriptions.DTOs;
using System.Net;

namespace ProjetoF.WebApi.Controllers
{
    [Route("api/alunos")]
    public class StudentsController : BaseController
    {
        public StudentsController(ISender mediator, NotificationHandler notificationHandler)
            : base(mediator, notificationHandler)
        { }

        /// <summary>
        /// Recupera todos os alunos ativos no banco de dados
        /// </summary>
        /// <response code="200">Retorna todos os alunos ativos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var query = new GetStudentsQuery();
            var result = await Sender.Send(query);

            return Response(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Recupera o usuário ativo com o id fornecido
        /// </summary>
        /// <param name="id">Identificador do aluno</param>
        /// <response code="200">Retorna o aluno</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetStudentByIdQuery(id);
            var result = await Sender.Send(query);

            return Response(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Cria um aluno
        /// </summary>
        /// <param name="dto">CreateStudentDto</param>
        /// <response code="200">Aluno criado com sucesso</response>
        /// <response code="400">Dados do aluno inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] RegisterStudentDto dto)
        {
            var command = dto.MapToCreateCommand();
            await Sender.Send(command);

            return Response(HttpStatusCode.OK);
        }

        /// <summary>
        /// Edita as informações de um aluno
        /// </summary>
        /// <param name="id">Identificador do aluno</param>
        /// <param name="dto">EditStudentDto</param>
        /// <response code="204">Informações do aluno atualizadas</response>
        /// <response code="400">Dados do aluno inválidos</response>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditStudentDto dto)
        {
            var command = dto.MapToEditCommand(id);
            await Sender.Send(command);

            return Response(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Desativa o aluno
        /// </summary>
        /// <param name="id">Identificador do aluno</param>
        /// <response code="204">Aluno desativado com sucesso</response>
        /// <response code="400">Dados do aluno inválidos</response>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DisableStudentCommand(id);
            await Sender.Send(command);

            return Response(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Adiciona uma assinatura ao aluno
        /// </summary>
        /// <param name="dto">AddSubscriptionDto</param>
        /// <response code="200">Assinatura criada e associada ao aluno com sucesso</response>
        /// <response code="400">Dados da assinatura inválidos</response>
        [HttpPost("assinatura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] SubscribeDto dto)
        {
            var command = dto.MapToSubscribeCommand();
            await Sender.Send(command);

            return Response(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove uma assinatura ao aluno
        /// </summary>
        /// <param name="dto">RemoveSubscriptionDto</param>
        /// <response code="200">Assinatura removida do aluno com sucesso</response>
        /// <response code="400">Dados da assinatura inválidos</response>
        [HttpDelete("assinatura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] CancelSubscriptionDto dto)
        {
            var command = dto.MapToCancelCommand();
            await Sender.Send(command);

            return Response(HttpStatusCode.NoContent);
        }
    }
}
