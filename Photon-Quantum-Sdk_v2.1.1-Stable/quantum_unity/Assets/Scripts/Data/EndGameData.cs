using System.Collections.Generic;
using Quantum;
public class EndGameData {
	public unsafe List<EndGameInfoElementData> RequestInfoForEndGame() {
		var game = QuantumRunner.Default.Game;
		var framesVerified = game.Frames.Verified;
		if (framesVerified == default) return null;
		var players = framesVerified.Filter<PlayerScore,PlayerLink>();
		List<EndGameInfoElementData> playerScores = new List<EndGameInfoElementData>();
		while (players.NextUnsafe(out var entityRef,out var score, out var link)) {
			var playerData = framesVerified.GetPlayerData(link->Player);
			var scores = score->Score;
			playerScores.Add(new EndGameInfoElementData() {
				Scores = scores,
				NickName = playerData.Nickname,
			});
		}
		return playerScores;
	}
}