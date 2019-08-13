import React, { Component } from 'react';



const ChessBoardFragment = ({ onSquareClick, availablePositions, color, figureColor, figureName,  isFigure, figure, onFigureClick, xPosition, yPosition }) => {

    let canBeMoved = false;
    if (availablePositions.positions) {
        canBeMoved = 
            availablePositions.positions.some(position => position.xPosition === xPosition && position.yPosition === yPosition);
    }


    return (
        <React.Fragment>
            {(!isFigure && canBeMoved) &&
                <div onClick={() => onSquareClick(xPosition, yPosition)} key={xPosition.toString() + yPosition.toString()} style={{ backgroundColor: 'green', opacity: "0.4", width: "calc(800px / 8)", height: "calc(800px / 8)" }}>
                <div key={yPosition.toString() + xPosition.toString()} style={{ color: figureColor, fontSize: "3rem", textAlign: "center", cursor: "pointer" }} onClick={() => onFigureClick(figureName, xPosition, yPosition)}>{figure}</div>
                </div>}
            {(isFigure && !canBeMoved) &&
                <div key={xPosition.toString() + yPosition.toString()} style={{ backgroundColor: color, width: "calc(800px / 8)", height: "calc(800px / 8)" }}>
                <div key={yPosition.toString() + xPosition.toString()}  style={{ color: figureColor, fontSize: "3rem", textAlign: "center", cursor: "pointer" }} onClick={() => onFigureClick(figureName, xPosition, yPosition)}>{figure}</div>
                </div>}
            {(!isFigure &&  !canBeMoved) &&
                <div onClick={() => onSquareClick(xPosition, yPosition)} key={xPosition.toString() + yPosition.toString()} style={{ backgroundColor: color, width: "calc(800px / 8)", height: "calc(800px / 8)" }}>
                </div>}
        </React.Fragment>
    );

};


export default ChessBoardFragment;