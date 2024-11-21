using LivroMente.API.Controllers;
using LivroMente.Service.Interfaces;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LivroMente.Tests.Controllers
{
    public class UploadControllerTest
    {
        private readonly UploadController _controller;
        private readonly Mock<IBlobService> _service;
        private readonly Mock<IMediator> _mediator;

        public UploadControllerTest()
        {
            _service = new Mock<IBlobService>();
            _mediator = new Mock<IMediator>();
            _controller = new UploadController(_service.Object,_mediator.Object);
        }

        

    }
}
