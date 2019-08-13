import React, { Component } from 'react';
import ChessBoard from './ChessBoard';
import axios from 'axios';


class ChessTutorial extends Component {

    state = {
        figures: [],
        selectedFigure : {}
    }


    componentDidMount() {
        axios.get("https://localhost:44359/api/chess/availablefigures")
            .then(response => {
                this.setState({
                    figures: [{ name : "Please select figure..."}, ...response.data]
                });

            })
            .catch(error => {
                alert("error during fetching data");
            });
    };

    handleFigureSelection = ({ target: select }) => {
        this.setState({
            selectedFigure: this.state.figures.filter(figure => figure.name === select.value)[0]
        });
    };


    getBoardSquares = () => {

        const squares = [];

        for (var row = 1; row <= 8; row++) {
            for (var column = 1; column <= 8; column++) {

                const isFigureHere = this.state.selectedFigure.currentPosition !== undefined &&
                    this.state.selectedFigure.currentPosition.xPosition === column &&
                    this.state.selectedFigure.currentPosition.yPosition === row;

                const figure = isFigureHere ? this.state.selectedFigure.unicodeSymbol : "";
                const figureName = isFigureHere ? this.state.selectedFigure.name : "";
                const color = row % 2 === column % 2 ? "white" : "black";
                const figureColor = color === "white" ? "black" : "white";

                squares.push({ isFigure: isFigureHere, figure: figure, figureName: figureName, xPosition: column, yPosition: row, color: color, figureColor: figureColor });
            }
        }


        return squares;

    };

    render() {
        return (
            <div className="container">

                <select className="form-control" onChange={this.handleFigureSelection} style={{ width: "200px", margin: "0 auto" }}>
                    {this.state.figures.map(figure =>
                        <option key={figure.name}>{figure.name}</option>
                    )}
                </select>
                <ChessBoard squares={this.getBoardSquares()} selectedFigure={this.state.selectedFigure} />
            </div>
            );
    }

}


export default ChessTutorial;