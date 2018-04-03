SELECT * FROM survey_result

SELECT * FROM park

SELECT COUNT(survey_result.parkCode) AS SurveyCount FROM survey_result
Group by parkCode
Order by SurveyCount DESC


SELECT COUNT(survey_result.parkCode) AS SurveyCount, park.parkName FROM survey_result
JOIN park on park.parkCode = survey_result.parkCode
Group by park.parkName
Order by SurveyCount DESC

SELECT COUNT(survey_result.parkCode) AS SurveyCount, park.parkName, park.inspirationalQuote, park.inspirationalQuoteSource FROM survey_result
JOIN park on park.parkCode = survey_result.parkCode
Group by park.parkName, park.inspirationalQuote, park.inspirationalQuoteSource
Order by SurveyCount DESC

INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)
VALUES ('GCNP', 'email@email.com', 'Alabama', 'Active');

SELECT COUNT(survey_result.parkCode) AS SurveyCount FROM survey_result
SELECT * FROM park WHERE parkCode = 'CVNP'

SELECT * FROM park 

SELECT COUNT(survey_result.parkCode) AS SurveyCount, park.acreage, park.acreage, park.climate,
park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource, park.milesOfTrail,
park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode, park.parkDescription, park.parkName
FROM survey_result
JOIN park ON park.parkCode = survey_result.parkCode
WHERE survey_result.parkCode = 'CVNP'

SELECT COUNT(survey_result.parkCode) AS survey_count, park.acreage, park.acreage, park.climate,
park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource, park.milesOfTrail,
park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode, park.parkDescription, park.parkName
FROM survey_result
JOIN park on park.parkCode = survey_result.parkCode
WHERE survey_result.parkCode = 'CVNP'
Group by park.acreage, park.acreage, park.climate,
park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource, park.milesOfTrail,
park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode, park.parkDescription, park.parkName
Order by survey_count DESC

