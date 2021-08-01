package utilTest;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.junit.MockitoJUnitRunner;
import util.WordUtil;

import static org.junit.jupiter.api.Assertions.*;

@RunWith(MockitoJUnitRunner.class)
public class WordUtilTest {
    private WordUtil wordUtil;
    private final String WORD = "Friends";
    private final String ROOT_WORD = "friend"; // TODO change after uncommenting stemmer
    private final String STOP_WORD = "be";

    @Before
    public void initialize() {
        wordUtil = new WordUtil();
    }

    @Test
    public void testExtractWord() {
        String result = wordUtil.extractRootWord(WORD);
        assertEquals(ROOT_WORD, result);
    }

    @Test
    public void testStopWord() {
        String result = wordUtil.extractRootWord(STOP_WORD);
        assertNull(result);
    }
}
