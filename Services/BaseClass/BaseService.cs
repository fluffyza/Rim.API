using AutoMapper;
using Microsoft.Extensions.Logging;
using Rim.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rim.API.Services
{
	public class BaseService
	{
		public readonly IMapper _mapper;
		public readonly ILogger _logger;
		public readonly Context _context;

		public BaseService(Context context, IMapper mapper, ILogger logger)
		{
			_context = context;
			_mapper = mapper;
			_logger = logger;
		}
	}
}
