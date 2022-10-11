namespace Quantum.Game;

public unsafe class PlayerScoreSystem : SystemMainThread, ISignalChangePlayerScore, ISignalOnPlayerDataSet {

	public override void Update(Frame f) {
	}
	public void ChangePlayerScore(Frame frame, int score, PlayerRef playerID) {
		// Log.Debug($"Try change player {playerID} score to: {score}");
		var players = frame.Filter<PlayerScore, PlayerLink>();
		while (players.NextUnsafe(out var e, out var scores, out var links)) {
			// Log.Debug($"Player {links->Player} score: {scores->Score}");
			var player = links->Player;
			var currentScore = scores->Score;
			var scoreToAdd = player.Equals(playerID) ? score : 0;
			scores->Score = currentScore + scoreToAdd;
		}
	}
	public void OnPlayerDataSet(Frame f, PlayerRef player) {
	}
}
