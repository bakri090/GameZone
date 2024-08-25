namespace GameZone.Service
{
	public interface IGamesService
	{
		Task Create(CreateGameFormViewModel model);
		Game? GetById(int id);
		Task<IEnumerable<Game>> GetAll();
		Task<Game?> Update (EditGameFormViewModel model);
		bool Delete (int id);
	}
}
