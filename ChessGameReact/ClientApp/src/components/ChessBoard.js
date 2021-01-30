import React, { Component } from 'react';
import ChessBoardFragment from './ChessBoardFragment';
import axios from 'axios';
import $ from 'jquery';

class ChessBoard extends Component {


    constructor(props) {
        super(props);

        this.state = {
            availablePositions: {},
        }


        $(document).on("change", "select", () => {
            this.setState({
                availablePositions: {}
            })
        })
    }



    handleFigureClick = (figureName, xPosition, yPosition) => {
        console.log("x", xPosition, "y", yPosition);
        axios.get(`https://localhost:44359/api/figures/availablemoves?figureName=${figureName}&xPosition=${xPosition}&yPosition=${yPosition}`)
            .then(result => {
                this.setState({
                    availablePositions: {
                        figureName: figureName,
                        positions: result.data
                    }
                })
            })
            .catch(error => {
                alert("error");
            })
    };

    handleSquareClick = (xPosition, yPosition) => {


        if (Object.keys(this.props.selectedFigure).length === 0) return;

        const initialXPos = this.props.selectedFigure.currentPosition.xPosition;
        const intialYPos = this.props.selectedFigure.currentPosition.yPosition;
        const figureName = this.props.selectedFigure.name;

        axios
            .get(`https://localhost:44359/api/figures/canmoveto?figureName=${figureName}&fromX=${initialXPos}&toX=${xPosition}&fromY=${intialYPos}&toY=${yPosition}`)
            .then(result => {


                if (result.data === true) {

                    const squares = this.props.squares;

                    let prevFigureSquare = this.props.squares.filter(square => square.xPosition === initialXPos && square.yPosition === intialYPos)[0];
                    let index = this.props.squares.indexOf(prevFigureSquare);
                    prevFigureSquare.isFigure = false;


                    let currFigureSquare = this.props.squares.filter(square => square.xPosition === xPosition && square.yPosition === yPosition)[0];
                    let index2 = this.props.squares.indexOf(currFigureSquare);
                    currFigureSquare.isFigure = true;
                    currFigureSquare.figureName = prevFigureSquare.figureName;
                    currFigureSquare.figure = prevFigureSquare.figure;

                    squares[index2] = currFigureSquare;

                    prevFigureSquare.figure = "";
                    squares[index] = prevFigureSquare;

                    const selectedFigure = this.props.selectedFigure;
                    selectedFigure.currentPosition.xPosition = xPosition;
                    selectedFigure.currentPosition.yPosition = yPosition;

                    console.log("prev", prevFigureSquare, "index", index);

                    this.setState({
                        availablePositions: {},
                    });
                }
                else {
                    alert("Move is invalid");
                }


            })
            .catch(error => {
                alert("error");
            })

    };

    render() {

        return (

            <div style={{ border: "2px solid black", width: "804px", margin: "0 auto" }}>
                <div style={{ width: "800px", height: "800px", display: "flex", flexWrap: "wrap" }}>
                    {this.props.squares.map(square =>
                        <ChessBoardFragment
                            key={this.props.squares.indexOf(square)}
                            onSquareClick={this.handleSquareClick}
                            availablePositions={this.state.availablePositions}
                            isFigure={square.isFigure}
                            figure={square.figure}
                            figureName={square.figureName}
                            xPosition={square.xPosition}
                            yPosition={square.yPosition}
                            color={square.color}
                            figureColor={square.figureColor}
                            onFigureClick={this.handleFigureClick} />)}
                </div>
            </div>
        )
    }
}


export default ChessBoard;