using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Requests;
using MediatR;




namespace LivroMente.Domain.Commands.PreferenceCommands
{
    public class PreferenceAddCommand :  IRequest<bool>
    {
        public PreferenceRequest PreferenceRequest { get; }

    public PreferenceAddCommand(PreferenceRequest preferenceRequest)
    {
        PreferenceRequest = preferenceRequest;
    }
    }
}