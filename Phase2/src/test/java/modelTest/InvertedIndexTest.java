package modelTest;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import model.DocumentFile;
import model.InvertedIndex;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class InvertedIndexTest {
    private InvertedIndex invertedIndex;
    private final String WORD = "friend";
    @Mock
    private DocumentFile documentFile;

    private void initializeInvertedIndex() {
        invertedIndex = new InvertedIndex();
    }

    @Test
    public void testAddDocument() {
        initializeInvertedIndex();
        invertedIndex.addDocument(documentFile);
        assertTrue(invertedIndex.getDocuments().contains(documentFile));
    }

    @Test
    public void testAddWord() {
        initializeInvertedIndex();
        invertedIndex.addWord(documentFile, WORD);
        var resultSet = invertedIndex.getOccurredDocuments(WORD);
        assertTrue(resultSet.contains(documentFile));
    }

    @Test
    public void testAddNullWord() {
        initializeInvertedIndex();
        var resultSet = invertedIndex.getOccurredDocuments(null);
        assertTrue(resultSet.isEmpty());
    }

    @Test
    public void testGetNullSet() {
        initializeInvertedIndex();
        var resultSet = invertedIndex.getOccurredDocuments(WORD);
        assertTrue(resultSet.isEmpty());
    }
}
