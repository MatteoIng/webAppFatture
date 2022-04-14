angular.module("fatturaApp", []).controller("fatturaCtrl", function ($scope,$http,$log) {

    $http.get("https://localhost:44342/Fattura/getAllFatture")
        .then(function (response) {
            $log.info(response)
            $scope.fatture=response.data       
        }, function (reason) {
            $log.info(reason)
            $scope.data=reason.data
        })




    $scope.getFatturaById = function (id) {
        $http.get("https://localhost:44342/Fattura/getFattura/" + id)
            .then(function (response) {
                $log.info(response)
                $scope.fattura = response.data
            }, function (reason) {
                $log.info(reason)
                $scope.data = reason.data
            })
    }


    $scope.updateFattur = function (fattura) {
        $http.put("https://localhost:44342/Fattura/updateFattura", fattura)
            .then(function (response) {
                $log.info(response)
                $scope.fatture = response.data
            }, function (reason) {
                $log.info(reason)
                $scope.data = reason.data
            })
    }



    $scope.ricerca = function (ric) {
        try {
            if (ric.numeroFattura == "" || ric.numeroFattura == undefined) {
                val1 = null
            } else {
                val1 = ric.numeroFattura
            }
            
            try {
                val2 = ric.dataFattura.toDateString()
                try {
                    val3 = ric.dataRicezione.toDateString()
                } catch {
                    val3 = null
                }
            } catch {
                val2 = null
                try {
                    val3 = ric.dataRicezione.toDateString()
                } catch {
                    val3=null
                }
            }
        } catch {
            val1 = null
            try {
                val2 = ric.dataFattura.toDateString()
                try {
                    val3 = ric.dataRicezione.toDateString()
                } catch {
                    val3=null
                }
            } catch {
                val2 = null
                try {
                    val3 = ric.dataRicezione.toDateString()
                } catch {
                    val3=null
                }
            }
           
        }
        
        
        url = "https://localhost:44342/Fattura/findFatture/" + val1 + "/" + val2 + "/" + val3
        $http.get(url)
            .then(function (response) {
                $log.info(response.data)
                $scope.fatture=response.data
            }, function (reason) {
                $log.info(reason)
                $scope.data=reason.data
        })
    }




    $scope.reverse = function () {
        $scope.fattura = null

    }
})
