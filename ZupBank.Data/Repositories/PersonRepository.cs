using Dapper;
using ZupBank.Application.Helpers;
using ZupBank.Data.Data.Connectors;
using ZupBank.Data.Data.Dapper;
using ZupBank.Data.Data.Models;
using ZupBank.Data.Mappers;
using ZupBank.Domain.Entities;
using ZupBank.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ZupBank.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonRepository : IPersonRepository
    {

        private readonly DbConnectionPerSQL _connectionPerSQL;
        private readonly IDapperColumnMapper _dapperColumnMapper;

        /// <summary>
        /// 
        /// </summary>
        public PersonRepository(DbConnectionPerSQL connectionPerSQL,
                                IDapperColumnMapper dapperColumnMapper)
        {
            _connectionPerSQL = connectionPerSQL;
            _dapperColumnMapper = dapperColumnMapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Person>> GetAll()
        {
            var map = _dapperColumnMapper.GetMapDapperColumn<PersonModel>();
            SqlMapper.SetTypeMap(typeof(PersonModel), map);

            using var connection = _connectionPerSQL.GetConnection();
            connection.Open();

            var persons = await connection.QueryAsync<PersonModel>("SP_PERSONS_GETALL",
                                                                  commandType: CommandType.StoredProcedure);

            return PersonModelMapper.ToDomainList(persons);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> Get(int id)
        {
            var map = _dapperColumnMapper.GetMapDapperColumn<PersonModel>();
            SqlMapper.SetTypeMap(typeof(PersonModel), map);

            using var connection = _connectionPerSQL.GetConnection();
            connection.Open();

            var person = await connection.QueryFirstOrDefaultAsync<PersonModel>("SP_PERSONS_GETBIYD",
                                                                                new { P_CODIGO = id },
                                                                                commandType: CommandType.StoredProcedure);

            return PersonModelMapper.ToDomain(person);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task Add(Person person)
        {
            var map = _dapperColumnMapper.GetMapDapperColumn<PersonModel>();
            SqlMapper.SetTypeMap(typeof(PersonModel), map);

            using var connection = _connectionPerSQL.GetConnection();
            connection.Open();

            var count = await connection.ExecuteAsync("SP_PERSONS_ADD",
                                                        new
                                                        {
                                                            P_CODIGO = person.Id,
                                                            P_NOME = person.Name,
                                                            P_GENERO = EnumHelper.GetDescription(person.Gender),
                                                            P_MES = EnumHelper.GetDescription(person.BirthdayMonth),
                                                        },
                                                        commandType: CommandType.StoredProcedure);

            if (count <= 0) throw new Exception("Error on saving person");
        }

    }
}
