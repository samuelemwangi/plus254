import React from "react";

export const convertNumberToRating = (rating, { ...stars }) => {
  const starValue = [];
  let ratingParts = [];
  const ratingValue = `${rating}`;

  if (ratingValue.includes(".")) {
    ratingParts = ratingValue.split(".");
  } else {
    ratingParts = [ratingValue, 0];
  }

  const intValue0 = parseInt(ratingParts[0], 10);
  const intValue1 = parseInt(ratingParts[1], 10);

  let countStar = 0;

  while (countStar < 5) {
    if (countStar < intValue0) {
      starValue.push(<stars.starFull key={countStar} />);
    } else if (countStar === intValue0 && intValue1 !== 0) {
      starValue.push(<stars.starHalf key={countStar} />);
    } else {
      starValue.push(<stars.starEmpty key={countStar} />);
    }

    countStar += 1;
  }

  return starValue;
};
