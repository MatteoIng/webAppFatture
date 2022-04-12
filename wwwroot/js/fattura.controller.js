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
            val1 = ric.numeroFattura
            val2 = ric.dataFattura.toDateString()
            val3 = ric.dataRicezione.toDateString()
        } catch {
            try {
                val1=null
                val2 = ric.dataFattura.toDateString()
                val3 = ric.dataRicezione.toDateString()
            }
            catch {
                try {
                    val1 = null
                    val2=null
                    val3 = ric.dataRicezione.toDateString()
                } catch {

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
})
