public class GameEngine {
    private static GameEngine m_engine = new GameEngine();

    private Stage m_stage;

    private GameEngine() {
    }

    public static GameEngine SharedInstance() {
        return m_engine;
    }

    public void SetStage(Stage stage) {
        m_stage = stage;
    }

    public Stage stage {
        get { return m_stage; }
    }
}