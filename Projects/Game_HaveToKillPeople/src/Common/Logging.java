package Common;
import java.util.logging.Logger;

public final class Logging {
    private static final Logger logger = Logger.getLogger(Logging.class.getName());
    
    public static void log (String message)
    {
        logger.info(message);
    }
}
