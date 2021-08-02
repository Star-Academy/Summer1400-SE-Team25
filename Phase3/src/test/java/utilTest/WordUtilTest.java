package utilTest;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.junit.MockitoJUnitRunner;
import util.WordUtil;

import java.io.FileNotFoundException;

import static org.junit.Assert.*;

@RunWith(MockitoJUnitRunner.class)
public class WordUtilTest {
    private WordUtil wordUtil;
    private final String WORD = "Friends";
    private final String ROOT_WORD = "friend";
    private final String STOP_WORD = "be";

    public void initialize() {
        wordUtil = new WordUtil();
    }

    @Test
    public void testExtractWord() {
        initialize();
        String result = wordUtil.extractRootWord(WORD);
        assertEquals(ROOT_WORD, result);
    }

    @Test
    public void testStopWord() {
        initialize();
        String result = wordUtil.extractRootWord(STOP_WORD);
        assertNull(result);
    }

    @Test
    public void testFileNotFoundException() {
        wordUtil = new WordUtil("src/main/java/StopWord");
    }
}
